FROM openjdk:21

WORKDIR /app

COPY target/webservice-0.0.1-SNAPSHOT.jar /app/myapp.jar

RUN mvn clean package -DskipTests

EXPOSE 8080

ENTRYPOINT ["java", "-jar", "myapp.jar"]