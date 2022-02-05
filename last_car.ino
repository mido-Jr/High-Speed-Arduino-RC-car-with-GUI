//---------------------------------------------------------------- //
// CI Lab Project 
// Team A5,
// Ahmed Mohamed ELnassag
// Hazem Alaa Mostafa
// Asmaa Fathey
// ---------------------------------------------------------------- //
#define echoPin 2 // attach pin D2 Arduino to pin Echo of HC-SR04
#define trigPin 3 //attach pin D3 Arduino to pin Trig of HC-SR04

// defines variables
long duration; // variable for the duration of sound wave travel
int distance; // variable for the distance measurement
char m=0;
void setup() 
{

pinMode(8, OUTPUT);  
pinMode(9, OUTPUT);  
pinMode(10, OUTPUT);
pinMode(11, OUTPUT);
pinMode(12, OUTPUT);
pinMode(trigPin, OUTPUT); // Sets the trigPin as an OUTPUT
pinMode(echoPin, INPUT); // Sets the echoPin as an INPUT

Serial.begin(9600);
}
void loop() 
{
 if (Serial.available()>0)
 {
  m=Serial.read();
  Serial.println(m);
  }

 // Clears the trigPin condition
    digitalWrite(trigPin, LOW);
    delayMicroseconds(2);
    
  // Sets the trigPin HIGH (ACTIVE) for 10 microseconds
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);
    
  // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(echoPin, HIGH);
    
  // Calculating the distance
    distance = duration * 0.034 / 2; // Speed of sound wave divided by 2 (go and back)
 if (m=='R')
{
  digitalWrite(9, HIGH);
  digitalWrite(10, LOW);
  digitalWrite(11, HIGH);
  digitalWrite(12, LOW);
  }

  else if (m=='L')
{
  
  digitalWrite(9, LOW);
  digitalWrite(10, HIGH);
  digitalWrite(11, LOW);
  digitalWrite(12, HIGH);
  }

else if (m=='F')
{
  digitalWrite(9, HIGH);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);
  digitalWrite(12, HIGH);
  
  }

 else if (m=='B')
{
  digitalWrite(9, LOW);
  digitalWrite(10, HIGH);
  digitalWrite(11, HIGH);
  digitalWrite(12, LOW);
  
  }
else if (m=='S')
{
  digitalWrite(9, LOW);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);
  digitalWrite(12, LOW);
  } 
  else if (m=='X')
{
  digitalWrite(8, HIGH);
  } 
  else if (m=='Z')
{
  digitalWrite(8, LOW);
 
  }
  else if (m=='D')
{
    Serial.print("Distance: ");
    Serial.print(distance);
    Serial.print(" cm \n");
    delay(100);
  
  } 
}
