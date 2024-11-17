package com.lausebscode.servicio;

import com.lausebscode.modelo.FeriaGastro;
import com.lausebscode.modelo.Organizador;
import com.lausebscode.repositorio.FeriaGastroRepositorio;
import com.lausebscode.repositorio.OrganizadorRepositorio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
public class OrganizadorServicioImpl implements OrganizadorServicio {

    @Autowired
    private OrganizadorRepositorio organizadorRepositorio;

    @Autowired
    private FeriaGastroRepositorio feriaGastroRepositorio;

    @Override
    @Transactional
    public Organizador crearOrganizador(Organizador organizador) {
        validarOrganizador(organizador);
        validarUnicidad(organizador);

        // Verificar que no exista un organizador con el mismo ID
        if (organizador.getId() != 0 && organizadorRepositorio.existsById(organizador.getId())) {
            throw new IllegalArgumentException("Ya existe un Organizador con el id: " + organizador.getId());
        }

        return organizadorRepositorio.save(organizador);
    }

    @Override
    public Organizador buscarPorId(int id) {
        return organizadorRepositorio.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró el Organizador con ID: " + id));
    }

    @Override
    public Organizador buscarPorNombre(String nombre) {
        if (nombre == null || nombre.trim().isEmpty()) {
            throw new IllegalArgumentException("El nombre no puede ser nulo o estar vacío");
        }

        return organizadorRepositorio.findByNombreIgnoreCase(nombre)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró el Organizador con nombre: " + nombre));
    }

    @Override
    @Transactional
    public void eliminarOrganizador(Organizador organizador) {
        organizadorRepositorio.delete(organizador);
    }

    @Override
    public List<Organizador> listarTodosLosOrganizadores() {
        return organizadorRepositorio.findAll();
    }

    @Override
    public List<Organizador> listarOrganizadoresPorInicial(String inicial) {
        if (inicial == null || inicial.trim().isEmpty()) {
            throw new IllegalArgumentException("La inicial no puede ser nula o estar vacía");
        }
        return organizadorRepositorio.findByNombreStartingWithIgnoreCase(inicial.trim());
    }

    @Override
    @Transactional
    public Organizador actualizarOrganizador(int id, Organizador nuevoOrganizador) {
        Organizador organizadorExistente = buscarPorId(id);

        if (!organizadorExistente.getNombre().equalsIgnoreCase(nuevoOrganizador.getNombre())) {
            validarUnicidadNombre(nuevoOrganizador);
        }

        organizadorExistente.setNombre(nuevoOrganizador.getNombre());
        organizadorExistente.setPresupuesto(nuevoOrganizador.getPresupuesto());
        organizadorExistente.setFundacion(nuevoOrganizador.getFundacion());
        organizadorExistente.setCeo(nuevoOrganizador.getCeo());

        return organizadorRepositorio.save(organizadorExistente);
    }

    @Override
    @Transactional
    public Organizador asignarFeriaGastro(int organizadorId, int feriaGastroId) {
        Organizador organizador = buscarPorId(organizadorId);
        FeriaGastro feriaGastro = feriaGastroRepositorio.findById(feriaGastroId)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con ID: " + feriaGastroId));

        // Verificar si el organizador ya está asignado a otra feria
        if (organizador.getFeriaGastro() != null && organizador.getFeriaGastro().getId() != feriaGastroId) {
            throw new IllegalArgumentException("El organizador ya está asignado a otra Feria Gastronómica");
        }

        organizador.setFeriaGastro(feriaGastro);
        return organizadorRepositorio.save(organizador);
    }

    private void validarOrganizador(Organizador organizador) {
        if (organizador == null) {
            throw new IllegalArgumentException("El Organizador no puede ser nulo");
        }
        if (organizador.getNombre() == null || organizador.getNombre().trim().isEmpty()) {
            throw new IllegalArgumentException("El nombre del Organizador no puede estar vacío");
        }
        if (organizador.getPresupuesto() < 0) {
            throw new IllegalArgumentException("El presupuesto del Organizador no puede ser negativo");
        }
        if (organizador.getFundacion() == null) {
            throw new IllegalArgumentException("La fecha de fundación del Organizador no puede estar vacía");
        }
        if (organizador.getCeo() == null || organizador.getCeo().trim().isEmpty()) {
            throw new IllegalArgumentException("El CEO del Organizador no puede estar vacío");
        }
    }

    private void validarUnicidad(Organizador organizador) {
        if (organizadorRepositorio.findByNombreIgnoreCase(organizador.getNombre()).isPresent()) {
            throw new IllegalArgumentException("Ya existe un Organizador con el nombre: " + organizador.getNombre());
        }
    }

    private void validarUnicidadNombre(Organizador organizador) {
        if (organizadorRepositorio.findByNombreIgnoreCase(organizador.getNombre()).isPresent()) {
            throw new IllegalArgumentException("Ya existe un Organizador con el nombre: " + organizador.getNombre());
        }
    }
}