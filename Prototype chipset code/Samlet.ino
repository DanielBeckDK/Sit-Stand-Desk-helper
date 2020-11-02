#include "SoftwareSerial.h"
#include "DFRobotDFPlayerMini.h"
#include <Adafruit_NeoPixel.h>
#include <hcsr04.h>
#include <WString.h>
#include <Ticker.h>


//-----------------------------------Various variables + timer
Ticker timer;

const byte x = 32;
char receivedData[x];
boolean newData = false;
int increaseCounter = 8;
int resetCounter = 9;
int standingTime = 15;
int sittingTime = 45;
int sitting = 7;
int stand = 6;
boolean standing;

//-----------------------------------------Ultrasonic sensor
const int trigPin = D5;
const int echoPin = D6;
long duration;
int distance;

//----------------------------------------------------LED
#define PIN   D7
#define N_LEDS 7

Adafruit_NeoPixel strip = Adafruit_NeoPixel(N_LEDS, PIN, NEO_GRB + NEO_KHZ800);
int ac1 = 0;
int ac2 = 0;
int ac3 = 255;
int sc1 = 0;
int sc2 = 255;
int sc3 = 0;

uint32_t actionColor = strip.Color(ac1, ac2, ac3);
uint32_t stayColor = strip.Color(sc1, sc2, sc3);
uint32_t badColor = strip.Color(255, 0, 0);

int intDataR;
int intDataG;
int intDataB;

//-----------------------------------------------------Speaker
SoftwareSerial mySoftwareSerial(D1, D2); // RX, TX
DFRobotDFPlayerMini myDFPlayer;
void printDetail(uint8_t type, int value);
int song = 1;


void setup()
{

   //Get distance, set boolean, send command via serial and start
   //timer all depending on the user position (distance)
  Serial.begin(115200);
  getDistance();

  if (distance < 85)
  {
    standing = false;
    Serial.println(stand);
    timer.attach(sittingTime, doSomething);
  }
  else
  {
    standing = true;
    Serial.println(sitting);
    timer.attach(standingTime, doSomething);
  }

  


  //Set pinmodes for Ultrasonic sensor

  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);  

  //Initialize strip, fill with color and update

  strip.begin();
  strip.fill(stayColor, 0);
  strip.show();


  //Initialize softwareserial, initialize soundcard using softwareserial
  //and set volume for soundcard. Delay added for error handling.

  mySoftwareSerial.begin(9600);  
  myDFPlayer.begin(mySoftwareSerial);
  myDFPlayer.volume(20);  //Set volume value. From 0 to 30
  delay(500);
}

void loop()
{
  //------------------------------------Perform actions dependent on distance

  getDistance();

  if (distance < 85 && standing == true)
  {
    strip.fill(stayColor, 0);
    timer.attach(sittingTime, doSomething);
    standing = false;
    Serial.println(sitting);
  }
  else if (distance > 85 && standing == false)
  {
    strip.fill(stayColor, 0);
    timer.attach(standingTime, doSomething);
    standing = true;
    Serial.println(stand);
  }

  //---------------------------------------Make sure LED updates

  actionColor = strip.Color(ac1, ac2, ac3);
  stayColor = strip.Color(sc1, sc2, sc3);
  strip.show(); //also updates the led's if changes has been made 

  //---------------------------------------Handle serial data
  
  receiveData();
  handleNewData();

}

  //----------------------------------doSomething executes when the user should act

void doSomething()
{
  strip.fill(actionColor, 0);
  timer.attach(10, didNothing);
  myDFPlayer.play(song);
  Serial.println(increaseCounter);
}

  //-------------------------------------didNothing executes when the user didn't act
  
void didNothing()
{
  myDFPlayer.play(song);  //Play the first mp3
  strip.fill(badColor, 0);
  timer.detach();
  Serial.println(resetCounter);
}

  //-------------------------------------------get the current distance
  
void getDistance()
{
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  duration = pulseIn(echoPin, HIGH);
  distance = duration * 0.034 / 2;
  delay(500);
}

  //-------------------------------------------recieveData manages serial data retrieval

void receiveData() {
  static boolean recvInProgress = false;
  static byte counter = 0;
  char startMarker = '<';
  char endMarker = '>';
  char rc;

  while (Serial.available() > 0 && newData == false) {
    rc = Serial.read();

    if (recvInProgress == true) {
      if (rc != endMarker) {
        receivedData[counter] = rc;
        counter++;
        if (counter >= x) {
          counter = x - 1;
        }
      }
      else {
        receivedData[counter] = '\0';
        recvInProgress = false;
        counter = 0;
        newData = true;
      }
    }

    else if (rc == startMarker) {
      recvInProgress = true;
    }
  }
}

  //-------------------------------handleNewData handles the data received in receiveData 

void handleNewData() {
  if (newData == true) {
    newData = false;
    String strData = receivedData;
    if (strData.indexOf('-') != NULL)
    {
      int firstDash = strData.indexOf('-');
      int secondDash = strData.indexOf('-', firstDash + 1);
      intDataR = strData.substring(1, firstDash).toInt();
      intDataG = strData.substring(firstDash + 1, secondDash).toInt();
      intDataB = strData.substring(secondDash + 1).toInt();
    }
    int intDataId = strData.substring(0, 1).toInt();

    switch (intDataId)
    {
      case 5:
        ac1 = intDataR;
        ac2 = intDataG;
        ac3 = intDataB;
        
        break;

      case 4:
        sc1 = intDataR;
        sc2 = intDataG;
        sc3 = intDataB;
        
        break;

      case 1:
        song = 1;
        
        break;

      case 2:
        song = 2;
        
        break;

      case 3:
        song = 3;
       
        break;

      case 6:
        standingTime = 15;
        sittingTime = 45;
        myDFPlayer.play(song);
        break;

      case 7:
        standingTime = 30;
        sittingTime = 45;
        myDFPlayer.play(song);
        break;

      case 8:
        standingTime = 30;
        sittingTime = 30;
        myDFPlayer.play(song);
        break;

      case 9:
        standingTime = 45;
        sittingTime = 15;
        myDFPlayer.play(song);
        break;

      case 0:
        standingTime = 20;
        sittingTime = 20;
        myDFPlayer.play(song);
        break;
    }
    intDataId = NULL;
  }
}
