package com.example.webservice;

import com.example.webservice.entity.Lobby;
import com.example.webservice.repository.LobbyRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.List;
import java.util.Optional;

@SpringBootApplication
@RequiredArgsConstructor
public class WebserviceApplication implements CommandLineRunner {
	private final LobbyRepository lobbyRepository;

	public static void main(String[] args) {
		SpringApplication.run(WebserviceApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Optional<Lobby> lobby = lobbyRepository.findByExist(true);
		if (lobby.isEmpty()){
			Lobby lobby1 = new Lobby();
			lobby1.setExist(true);
			lobbyRepository.save(lobby1);
		}
	}
}
