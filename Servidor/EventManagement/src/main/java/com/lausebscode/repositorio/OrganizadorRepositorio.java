package com.lausebscode.repositorio;

import com.lausebscode.modelo.Organizador;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface OrganizadorRepositorio extends JpaRepository<Organizador, Integer> {
    Optional<Organizador> findByNombreIgnoreCase(String nombre);

    @Query("SELECT o FROM Organizador o WHERE LOWER(o.nombre) LIKE LOWER(CONCAT(:inicial, '%'))")
    List<Organizador> findByNombreStartingWithIgnoreCase(@Param("inicial") String inicial);
}