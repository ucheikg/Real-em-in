// Rotation Encoding thing
const int clkPin = 5; // clock pin :)
const int dtPin = 4; // data pin
const int swPin = 3; //switch pin
bool On = false;

// Joy stick
const int SW_pin = 2; //digital pin connected to switch output
const int X_pin = 0; //analog pin connected to x output
const int Y_pin = 1; //analog pin connected to y output


unsigned long lastDebounceTime = 0;
char handshake = 'x';
const unsigned long debounceDelay = 5;
unsigned long lastDecrementTime = 0;
void setup() {

  pinMode(SW_pin, INPUT);
  digitalWrite(SW_pin, HIGH);
//  Serial.begin(115200);
  Serial.begin(9600);
  pinMode(clkPin, INPUT);
  pinMode(dtPin, INPUT_PULLUP);
  pinMode(swPin, INPUT_PULLUP);

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


//  Serial.print("Switch:  ");
//  Serial.println(digitalRead(SW_pin));
//  Serial.print("\n");
//  Serial.print("X-axis: ");
//  Serial.println(analogRead(X_pin));
//  Serial.print("\n");
//  Serial.print("Y-axis: ");
//  Serial.println(analogRead(Y_pin));
//  Serial.print("\n\n");
//
//  Serial.println(digitalRead(swPin));

  Serial.println(digitalRead(clkPin));

  if (!Serial.available()) {
    return;
  }
  //otherwise read the serial
  char inp = Serial.read();

  //If we receive 'a' then I know that I want to read the analogue sensor so send back that data
  if (inp == 'a') {
    Serial.println(digitalRead(clkPin));
  }
}
