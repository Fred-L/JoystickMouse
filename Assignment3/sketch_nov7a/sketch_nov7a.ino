unsigned long lastTime = 0;
byte AInput = 5;
byte BInput = 6;
byte lastState = 0;
byte steps = 0;
int led = 9;
int cw = 0;
byte AState = 0;
byte BState = 0;
byte State = 0;

void setup() {
  Serial.begin(9600);
  int X = 0;
  pinMode(2, INPUT);
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.begin(9600);
  pinMode(10, OUTPUT);
  pinMode(10, INPUT);
  pinMode(11, OUTPUT);
  pinMode(11, INPUT);
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  pinMode(7, INPUT);
  pinMode(8, INPUT);
  pinMode(9, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(AInput, INPUT);
  pinMode(BInput, INPUT);
}

void loop() {
  if (millis() > lastTime + 5000) {
    Serial.println("Still alive");
    lastTime = millis();
  }

  switch (Serial.read()) {
    case 'A':
      Serial.println("Recieved 'A' on Arduino!");
      break;
  }

  AState = digitalRead(AInput);
  BState = digitalRead(BInput) << 1;
  State = AState | BState;

  if (lastState != State) {
    switch (State) {
      case 0:
        if (lastState == 2) {
          steps++;
          cw = 1;
        } else if (lastState == 1) {
          steps--;
          cw = -1;
        }
        break;
      case 1:
        if (lastState == 0) {
          steps++;
          cw = 1;
        } else if (lastState == 3) {
          steps--;
          cw = -1;
        }
        break;
      case 2:
        if (lastState == 3) {
          steps++;
          cw = 1;
        } else if (lastState == 0) {
          steps--;
          cw = -1;
        }
        break;
      case 3:
        if (lastState == 1) {
          steps++;
          cw = 1;
        } else if (lastState == 2) {
          steps--;
          cw = -1;
        }
        break;
    }


    if (digitalRead(2) == HIGH) {
      digitalWrite(LED_BUILTIN, HIGH);
      Serial.println("Mouse 1");
      digitalWrite(LED_BUILTIN, LOW);
      digitalWrite(10, HIGH);

      if (digitalRead(10) == HIGH) {
        Serial.println("Vibrating");
      }
      digitalWrite(10, LOW);
      digitalWrite(11, HIGH);
      if (digitalRead(11) == HIGH) {
        Serial.println("Light On");
      }
      analogWrite(11, LOW);
    }

    if (digitalRead(3) == HIGH) {
      digitalWrite(LED_BUILTIN, HIGH);
      Serial.println("Mouse 2");
      digitalWrite(LED_BUILTIN, LOW);
      digitalWrite(11, HIGH);
      if (digitalRead(11) == HIGH) {
        Serial.println("Light On");
      }
      analogWrite(11, LOW);
      if (digitalRead(10) == HIGH) {
        Serial.println("Vibrating");
      }
    }



    /*
  if (digitalRead(4) == HIGH) {
    digitalWrite(LED_BUILTIN, HIGH);
    Serial.println("Middle Mouse");
    digitalWrite(LED_BUILTIN, LOW);
    digitalWrite(11, HIGH);
    if (digitalRead(11) == HIGH) {
      Serial.println("Light On");
    }
    analogWrite(11, LOW);
    if (digitalRead(10) == HIGH) {
      Serial.println("Vibrating");
    }
  }
 
  if (digitalRead(7) == HIGH) {
    digitalWrite(LED_BUILTIN, HIGH);
    Serial.println("Joystick Input");
    digitalWrite(LED_BUILTIN, LOW);
    digitalWrite(10, HIGH);
    if (digitalRead(10) == HIGH) {
      Serial.println("Vibrating");
    }
    digitalWrite(11, HIGH);
    if (digitalRead(11) == HIGH) {
      Serial.println("Light On");
    }
    analogWrite(11, LOW);
  }
    */
    if (analogRead(A1) != 511) {
      Serial.print("Analog 1: ");
      Serial.println(analogRead(A1));
      Serial.println("");
    }
    if (analogRead(A2) != 511) {
      Serial.print("Analog 2: ");
      Serial.println(analogRead(A2));
      Serial.println("");
      delay(1000);  // Wait for 1000 millisecond(s)
    }

    /*
  if (analogRead(A3) < 511) {
    Serial.println("Scrolling Down");
    Serial.println("");
    delay(1000); // Wait for 1000 millisecond(s)
  }
  if (analogRead(A3) > 511) {
    Serial.println("Scrolling Up");
    Serial.println("");
    delay(1000); // Wait for 1000 millisecond(s)
  }
*/
  }
  analogWrite(led, steps);
  lastState = State;
  Serial.print(State);
  Serial.print("\t");
  Serial.print(cw);
  Serial.print("\t");
  Serial.println(steps);
  delay(1);
}