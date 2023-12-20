# cluster-test
This is a simple .NET WebAPI application to validate our k8s clusters.

# Deployment
1. docker pull mvptest.azurecr.io/testapp:latest
2. push the image to JFrog 
3. Modify image path at deployment.yaml
4. Modify the connection string, API URL, Kafka endpoint (bootstrap service name:port), and Kafka topic at config.yaml accordingly
5. Apply Kafka/Topic.yaml to create Kafka topic
6. Apply config.yaml
7. Apply deployment-with-config.yaml
8. Apply Service-node-port.yaml

# Usage
1. Basic test for validating LB, namespace, RBAC, Network policy, JFrog etc.Will include Vault access.       
  htttp://Node-IP:30000/WeatherForecast
2. Invoke external API (http://api.weatherapi.com) for validating proxy setting   
  htttp://Node-IP:3000/WeatherForecastApi
3. Access DB ( Get list of tables from postgres DB) 
   htttp://Node-IP:3000/WeatherForecastDb
4. Access Kafka (Send one message to Kafka topic)
   htttp://Node-IP:3000/WeatherForecastMsg
5. All in one (WIP)        
   http://Node-IP:3000/WeatherForecastAll
