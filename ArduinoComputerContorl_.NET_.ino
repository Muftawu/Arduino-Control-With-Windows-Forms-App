#include "LiquidCrystal.h"

LiquidCrystal lcd(7, 8, 9, 10, 11, 12);

// LED PARAMETERS
#define redLED     6
#define blueLED    3
#define greenLED   4
#define yellowLED  5

String inputString;
String Action;
String LCD_Command;
String LED_Command;

void setup () {
  Serial.begin(9600);
  Serial.setTimeout(10);
  for (int a = 3; a < 7; a++) {
    pinMode(a, OUTPUT);
  }
  lcd.setCursor(0, 1);
//  lcd.print("Hello");
}

void loop () {
  Toogle_LEDS ();
}

// $LEDRON  LEDROF
// $LCD_HELLO/n

void Toogle_LEDS () {
  while (Serial.available()) {
    char c = Serial.read();

    if ( c == '$') {
      inputString = Serial.readString();

      // Check to see which action to be performed
      Action = inputString.substring(0, 3);
      
    }
    if (Action == "LED") {

      LED_Command = inputString.substring(3, 6);

      if (LED_Command == "GON") {
        Turn_On_GreenLED();
      }

      else if (LED_Command == "BON") {
        Turn_On_BlueLED();
      }

      else if (LED_Command == "RON") {
        Turn_On_RedLED();
      }

      else if (LED_Command == "YON") {
        Turn_On_YellowLED();
      }

      else if (LED_Command == "ROF") {
        Turn_Off_RedLED();
      }

      else if (LED_Command == "GOF") {
        Turn_Off_GreenLED();
      }

      else if (LED_Command == "BOF") {
        Turn_Off_BlueLED();
      }

      else if (LED_Command == "YOF") {
        Turn_Off_YellowLED();
      }
    }

    if (Action == "LCD") {
      inputString.remove(inputString.indexOf('\n'));
      LCD_Command = inputString.substring(4, 20);
      lcd.clear();
      lcd.setCursor(0, 1);
      lcd.print(LCD_Command);
    }
  }
}


void  Turn_On_RedLED() {
  digitalWrite(redLED, HIGH);
}

void  Turn_Off_RedLED() {
  digitalWrite(redLED, LOW);
}

void  Turn_On_BlueLED() {
  digitalWrite(blueLED, HIGH);
}

void  Turn_Off_BlueLED() {
  digitalWrite(blueLED, LOW);
}

void  Turn_On_YellowLED() {
  digitalWrite(yellowLED, HIGH);
}

void  Turn_Off_YellowLED() {
  digitalWrite(yellowLED, LOW);
}

void  Turn_On_GreenLED() {
  digitalWrite(greenLED, HIGH);
}

void  Turn_Off_GreenLED() {
  digitalWrite(greenLED, LOW);
}
