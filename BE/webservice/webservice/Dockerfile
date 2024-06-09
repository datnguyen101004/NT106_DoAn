FROM openjdk:21

WORKDIR /app

COPY target/webservice-0.0.1-SNAPSHOT.jar /app/myapp.jar

EXPOSE 8080

ENTRYPOINT ["java", "-jar", "myapp.jar"]