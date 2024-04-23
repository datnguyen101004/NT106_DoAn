package com.example.webservice.repository;

import com.example.webservice.entity.ListRoom;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ListRoomRepository extends JpaRepository<ListRoom, Long> {
}
