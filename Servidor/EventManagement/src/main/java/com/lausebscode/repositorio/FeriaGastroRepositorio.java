package com.lausebscode.repositorio;

import com.lausebscode.modelo.FeriaGastro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface FeriaGastroRepositorio extends JpaRepository<FeriaGastro, Integer> {
    Optional<FeriaGastro> findByNombreIgnoreCase(String nombre);

    @Query("SELECT f FROM FeriaGastro f WHERE f.precio <= :precioMaximo")
    List<FeriaGastro> findByPrecioLessThanEqual(@Param("precioMaximo") double precioMaximo);

}