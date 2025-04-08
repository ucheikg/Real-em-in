const int clkPin = 5;
const int dtPin = 4;
const int swPin = 3;
char handshake = 'x';
int trend = 0;
bool spinning = false;
int counter = 0;
int lastvalue = 0;
int lastClkState;
unsigned long lastDebounceTime = 0;
const unsigned long debounceDelay = 5;
unsigned long lastDecrementTime = 0;
void setup() {
  Serial.begin(9600);
  pinMode(clkPin, INPUT);
  pinMode(dtPin, INPUT);
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
      counter++; // Only increments on clockwise rotation
    }
  }
  lastClkState = currentClkState;
  // Automatically decrease the counter every second
  if (millis() - lastDecrementTime >= 75) {
    lastDecrementTime = millis();
    counter--;
  }

  if (counter != lastvalue) {
    trend = counter - lastvalue;
    if (trend > 0) {
      spinning = true;
    } else {
      spinning = false;
    }

  }
  lastvalue = counter;
  

  if (!Serial.available()) {
    return;
  }
  //otherwise read the serial
  char inp = Serial.read();

  //If we receive 'a' then I know that I want to read the analogue sensor so send back that data
  if (inp == 'a') {
    Serial.println(digitalRead(spinning));
  }

}
