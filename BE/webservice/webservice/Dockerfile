FROM openjdk:21

WORKDIR /app

RUN mvn clean package -DskipTests

COPY target/webservice-0.0.1-SNAPSHOT.jar /app/myapp.jar

EXPOSE 8080

ENTRYPOINT ["java", "-jar", "myapp.jar"]