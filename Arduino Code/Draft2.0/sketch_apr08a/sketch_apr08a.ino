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
  if (counter > threshold){
    spinning = true;
  } else if (counter < threshold){
    spinning = false;
  }

  if (!Serial.available()) {
    return;
  }
  //otherwise read the serial
  char inp = Serial.read();

  //If we receive 'a' then I know that I want to read the analogue sensor so send back that data
  if (inp == 'a') {
    Serial.println(spinning);
  }

}
