#include <DHT.h>
#include <WiFi.h>
#include <PubSubClient.h>
#include <ArduinoJson.h>
#include "config.h"

#define DHTPIN 5       // D5 pin for DHT11 sensor
#define DHTTYPE DHT11   // Type of DHT sensor (DHT11 or DHT22)

#define MQ7_PIN 4      // GPIO4 (ADC2_0) pin for MQ7 sensor
#define MQ135_PIN 2    // GPIO2 (ADC2_2) pin for MQ135 sensor

DHT dht(DHTPIN, DHTTYPE);
WiFiClient espClient;
PubSubClient client(espClient);

void setup_wifi() {
  delay(10);
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(SSID);
  WiFi.begin(SSID, PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void reconnect() {
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    if (client.connect("ESP32Client")) {
      Serial.println("connected");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      delay(5000);
    }
  }
}

void setup() {
  Serial.begin(9600);
  dht.begin();
  setup_wifi();
  client.setServer(MQTT_BROKER, MQTT_PORT);
}

void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();

  
  float temperature = dht.readTemperature();  // Read temperature (in Celsius)
  float humidity = dht.readHumidity();        // Read humidity (in %)

  if (isnan(temperature) || isnan(humidity)) {
    Serial.println("Failed to read from DHT sensor!");
    return;
  }

  float mq7Voltage = analogRead(MQ7_PIN) * (5.0 / 4095.0); // Convert analog reading to voltage (ESP32 ADC resolution is 12 bits)
  float mq7PPM = 10 * mq7Voltage; // Convert voltage to PPM (Parts Per Million)

  float mq135Voltage = analogRead(MQ135_PIN) * (5.0 / 4095.0); // Convert analog reading to voltage (ESP32 ADC resolution is 12 bits)
  // Adjust this formula based on your MQ135 calibration

  // Create JSON payload
  StaticJsonDocument<200> jsonDocument;
  jsonDocument["temperature"] = temperature;
  jsonDocument["humidity"] = humidity;
  jsonDocument["mq7_PPM"] = mq7PPM;
  jsonDocument["mq135_PPM"] = mq135Voltage;

  // Serialize JSON to string
  char buffer[200];
  serializeJson(jsonDocument, buffer);

  // Publish JSON payload to MQTT broker
  client.publish(MQTT_TOPIC, buffer);
  Serial.println("Published data to MQTT broker:");
  Serial.println(buffer);
  delay(5000);  // Delay between sensor readings
}
