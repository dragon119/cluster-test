# cluster-test
This is a simple .NET WebAPI application to validate our k8s clusters.

# Deployment
1. docker pull mvptest.azurecr.io/testapp:latest
2. Push the image to JFrog
3. Clone this repo
4. Modify image path (one in JFrog) at deployment.yaml      
5. Modify the connection string, API URL, Kafka endpoint (bootstrap service name:port), and Kafka topic at config.yaml accordingly
6. Apply Kafka/Topic.yaml to create Kafka topic if needed
7. Edit each endpoint in the config.yaml and Apply config.yaml
8. Apply deployment-with-config.yaml
9. Apply service-node-port.yaml

# Usage
1. Basic test for validating namespace, RBAC, Network policy, JFrog etc.Will include Vault access.         
  htttp://Node-IP:30000/WeatherForecast
2. Invoke external API (http://api.weatherapi.com) for validating proxy setting    
  htttp://Node-IP:3000/WeatherForecastApi
3. Access DB ( Get list of tables from postgres DB) for validating DB access        
   htttp://Node-IP:3000/WeatherForecastDb
4. Access Kafka (Send one message to Kafka topic) for validating Kafka access       
   htttp://Node-IP:3000/WeatherForecastMsg
5. All in one (WIP)        
   http://Node-IP:3000/WeatherForecastAll
