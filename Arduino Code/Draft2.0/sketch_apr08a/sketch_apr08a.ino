
const int SW_pin = 2; //digital pin connected to switch output
const int X_pin = A0; //analog pin connected to x output
const int Y_pin = A1; //analog pin connected to y output
bool up;
bool down;
bool right;
bool left;
int deadzone = 300;


const int clkPin = 5;
const int dtPin = 4;
const int swPin = 3;

char handshake = 'x';

int threshold = 90;
int counter = 0;
int counterMin = 0;
int counterMax = 100;

bool spinning = false;

int lastClkState;
unsigned long lastDebounceTime = 0;
const unsigned long debounceDelay = 5;
unsigned long lastDecrementTime = 0;


void setup() {
  Serial.begin(9600);
  pinMode(clkPin, INPUT_PULLUP);
  pinMode(dtPin, INPUT_PULLUP);
  pinMode(swPin, INPUT_PULLUP);
  lastClkState = digitalRead(clkPin);

  bool online = false;
  while (!online) {
    while (!Serial.available()) {
    }

    char inp = Serial.read();
    //If we receive the handshake character then we are online allowed to continue
    if (inp == handshake) {
      Serial.println(handshake);
      online = true;
    }
  }
}
void loop() {
  int currentClkState = digitalRead(clkPin);
  // Check for rotary encoder movement
  if (currentClkState != lastClkState && millis() - lastDebounceTime > debounceDelay) {
    lastDebounceTime = millis();
    if (digitalRead(dtPin) != currentClkState) {
      if (counter < counterMax) {
        counter++;
        spinning = true;
      }
    }
  }
  lastClkState = currentClkState;
  // Automatically decrease the counter every second
  if (millis() - lastDecrementTime >= 75) {
    lastDecrementTime = millis();
    if (counterMax >= counter > counterMin && counter != 0) {
      counter--;
      spinning = false;
    }
  }
  if (counter > threshold) {
    spinning = true;
  } else if (counter < threshold) {
    spinning = false;
  }


  int x = analogRead(X_pin);
  int y = analogRead(Y_pin);

  if (533 + deadzone < x && x <= 1023) {
    right = true;
    left = false;
  }


  if (0 <= x && x < 0 + deadzone) {
    right = false;
    left = true;
  }

  if (533 - deadzone <= x && x <= 533 + deadzone) {
    right = false;
    left = false;
  }


  if (533 + deadzone < y && y <= 1023) {
    up = true;
    down = false;
  }


  if (0 <= y && y < 0 + deadzone) {
    up = false;
    down = true;
  }

  if (533 - deadzone <= y && y <= 533 + deadzone) {
    up = false;
    down = false;
  }

  if (!Serial.available()) {
    return;
  }
  //otherwise read the serial
  char inp = Serial.read();

  //If we receive 'a' then I know that I want to read the analogue sensor so send back that data in the form of a bool  
  if (inp == 'a') {
    Serial.println(spinning);
  }

  if (inp == 'b') {
    Serial.println(up);
  }

  if (inp == 'c') {
    Serial.println(down);
  }

  if (inp == 'd') {
    Serial.println(right);
  }

  if (inp == 'e') {
    Serial.println(left);
  }

}
