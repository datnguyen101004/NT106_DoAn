package com.example.webservice.repository;

import com.example.webservice.entity.Lobby;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface LobbyRepository extends JpaRepository<Lobby, Long> {
    Optional<Lobby> findByExist(Boolean exist);
}
