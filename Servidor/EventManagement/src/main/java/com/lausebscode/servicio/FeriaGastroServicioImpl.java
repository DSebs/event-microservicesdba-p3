package com.lausebscode.servicio;


import com.lausebscode.modelo.FeriaGastro;
import com.lausebscode.repositorio.FeriaGastroRepositorio;
import com.lausebscode.servicio.FeriaGastroServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class FeriaGastroServicioImpl implements FeriaGastroServicio {

    @Autowired
    private FeriaGastroRepositorio feriaGastroRepositorio;

    @Override
    public FeriaGastro crearFeriaGastro(FeriaGastro feriaGastro) {
        validarFeriaGastro(feriaGastro);
        validarUnicidad(feriaGastro);
        return feriaGastroRepositorio.save(feriaGastro);
    }

    @Override
    public FeriaGastro buscarPorId(int id) {
        return feriaGastroRepositorio.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con ID: " + id));
    }

    @Override
    public FeriaGastro buscarPorNombre(String nombre) {
        return feriaGastroRepositorio.findByNombre(nombre)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con nombre: " + nombre));
    }

    @Override
    public void eliminarFeriaGastro(FeriaGastro feriaGastro) {
        feriaGastroRepositorio.delete(feriaGastro);
    }

    @Override
    public List<FeriaGastro> listarTodasLasFeriasGastro() {
        return feriaGastroRepositorio.findAll();
    }

    @Override
    public List<FeriaGastro> listarFeriasGastroMenorIgualPrecio(double precioMaximo) {
        return feriaGastroRepositorio.findByPrecioLessThanEqual(precioMaximo);
    }

    @Override
    public FeriaGastro actualizarFeriaGastro(int id, FeriaGastro nuevoFeriaGastro) {
        FeriaGastro feriaGastroExistente = buscarPorId(id);

        if (!feriaGastroExistente.getNombre().equalsIgnoreCase(nuevoFeriaGastro.getNombre())) {
            validarUnicidadNombre(nuevoFeriaGastro);
        }

        feriaGastroExistente.setNombre(nuevoFeriaGastro.getNombre());
        feriaGastroExistente.setPrecio(nuevoFeriaGastro.getPrecio());
        feriaGastroExistente.setFechaRealizacion(nuevoFeriaGastro.getFechaRealizacion());
        feriaGastroExistente.setTipo(nuevoFeriaGastro.getTipo());

        return feriaGastroRepositorio.save(feriaGastroExistente);
    }

    private void validarFeriaGastro(FeriaGastro feriaGastro) {
        if (feriaGastro == null) {
            throw new IllegalArgumentException("La Feria Gastronómica no puede ser nula");
        }
        if (feriaGastro.getNombre() == null || feriaGastro.getNombre().trim().isEmpty()) {
            throw new IllegalArgumentException("El nombre de la Feria Gastronómica no puede estar vacío");
        }
        if (feriaGastro.getPrecio() < 0) {
            throw new IllegalArgumentException("El precio de la Feria Gastronómica no puede ser negativo");
        }
        if (feriaGastro.getFechaRealizacion() == null) {
            throw new IllegalArgumentException("La fecha de realización de la Feria Gastronómica no puede estar vacía");
        }
        if (feriaGastro.getTipo() == null || feriaGastro.getTipo().trim().isEmpty()) {
            throw new IllegalArgumentException("El tipo de la Feria Gastronómica no puede estar vacío");
        }
    }

    private void validarUnicidad(FeriaGastro feriaGastro) {
        if (feriaGastroRepositorio.findByNombre(feriaGastro.getNombre()).isPresent()) {
            throw new IllegalArgumentException("Ya existe una Feria Gastronómica con el nombre: " + feriaGastro.getNombre());
        }
    }

    private void validarUnicidadNombre(FeriaGastro feriaGastro) {
        if (feriaGastroRepositorio.findByNombre(feriaGastro.getNombre()).isPresent()) {
            throw new IllegalArgumentException("Ya existe una Feria Gastronómica con el nombre: " + feriaGastro.getNombre());
        }
    }
}
