package com.lausebscode.repositorio;

import com.lausebscode.modelo.FeriaGastro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface FeriaGastroRepositorio extends JpaRepository<FeriaGastro, Integer> {
    Optional<FeriaGastro> findByNombre(String nombre);

    List<FeriaGastro> findByPrecioLessThanEqual(double precioMaximo);
}