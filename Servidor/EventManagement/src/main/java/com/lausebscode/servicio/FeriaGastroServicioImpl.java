package com.lausebscode.servicio;


import com.lausebscode.dto.FeriaGastroDTO;
import com.lausebscode.modelo.FeriaGastro;
import com.lausebscode.modelo.Organizador;
import com.lausebscode.repositorio.FeriaGastroRepositorio;
import com.lausebscode.repositorio.OrganizadorRepositorio;
import com.lausebscode.servicio.FeriaGastroServicio;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class FeriaGastroServicioImpl implements FeriaGastroServicio {

    @Autowired
    private FeriaGastroRepositorio feriaGastroRepositorio;

    @Autowired
    private OrganizadorRepositorio organizadorRepositorio;

    @Override
    @Transactional
    public FeriaGastroDTO crearFeriaGastro(FeriaGastroDTO feriaGastroDTO) {
        // Convertir el DTO a entidad
        FeriaGastro feriaGastro = convertirDTOaEntidad(feriaGastroDTO);

        // Validaciones
        validarFeriaGastro(feriaGastro);
        validarUnicidad(feriaGastro);

        // Guardar la feria gastronómica (sin organizadores asociados aún)
        FeriaGastro feriaGastroGuardada = feriaGastroRepositorio.save(feriaGastro);

        // Verificar si hay organizadores para asociar
        if (feriaGastroDTO.getOrganizadorIds() != null && !feriaGastroDTO.getOrganizadorIds().isEmpty()) {
            // Obtener los organizadores por sus IDs
            List<Organizador> organizadores = organizadorRepositorio.findAllById(feriaGastroDTO.getOrganizadorIds());

            // Validar que los organizadores no estén ya asociados a otras ferias
            for (Organizador organizador : organizadores) {
                if (organizador.getFeriaGastro() != null) {
                    throw new IllegalArgumentException(
                            "El organizador con ID " + organizador.getId() + " ya está asociado a otra feria gastronómica."
                    );
                }
            }

            // Actualizar la lista de organizadores sin reemplazarla
            feriaGastroGuardada.getOrganizadores().clear();
            feriaGastroGuardada.getOrganizadores().addAll(organizadores);

            // Actualizar la referencia inversa de cada organizador
            organizadores.forEach(org -> org.setFeriaGastro(feriaGastroGuardada));
        }

        // Retornar el DTO de la feria creada
        return convertirEntidadaDTO(feriaGastroGuardada);
    }
    @Override
    public FeriaGastro buscarPorId(int id) {
        return feriaGastroRepositorio.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con ID: " + id));
    }

    @Override
    public FeriaGastro buscarPorNombre(String nombre) {
        if (nombre == null || nombre.trim().isEmpty()) {
            throw new IllegalArgumentException("El nombre no puede ser nulo o estar vacío");
        }

        return feriaGastroRepositorio.findByNombreIgnoreCase(nombre)
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
        if (precioMaximo < 0) {
            throw new IllegalArgumentException("El precio máximo no puede ser negativo");
        }
        return feriaGastroRepositorio.findByPrecioLessThanEqual(precioMaximo);
    }

    @Override
    @Transactional
    public FeriaGastroDTO actualizarFeriaGastro(int id, FeriaGastroDTO feriaGastroDTO) {
        FeriaGastro feriaGastroExistente = buscarPorId(id);

        // Actualizar campos básicos
        feriaGastroExistente.setNombre(feriaGastroDTO.getNombre());
        feriaGastroExistente.setPrecio(feriaGastroDTO.getPrecio());
        feriaGastroExistente.setFechaRealizacion(feriaGastroDTO.getFechaRealizacion());
        feriaGastroExistente.setTipo(feriaGastroDTO.getTipo());

        // Actualizar organizadores
        if (feriaGastroDTO.getOrganizadorIds() != null) {
            // Desasociar organizadores actuales
            feriaGastroExistente.getOrganizadores().forEach(org -> org.setFeriaGastro(null));

            // Asociar nuevos organizadores
            List<Organizador> nuevosOrganizadores = organizadorRepositorio
                    .findAllById(feriaGastroDTO.getOrganizadorIds());
            nuevosOrganizadores.forEach(org -> org.setFeriaGastro(feriaGastroExistente));
            feriaGastroExistente.setOrganizadores(nuevosOrganizadores);
        }

        FeriaGastro feriaGastroActualizada = feriaGastroRepositorio.save(feriaGastroExistente);
        return convertirEntidadaDTO(feriaGastroActualizada);
    }

    private void validarFeriaGastro(FeriaGastro feriaGastro) {
        if (feriaGastro == null) {
            throw new IllegalArgumentException("La Feria Gastronómica no puede ser nula");
        }
        if (feriaGastro.getId() <= 0) {
            throw new IllegalArgumentException("El id de la cancion no puede ser null");
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
    }

    private void validarUnicidad(FeriaGastro feriaGastro) {
        if (feriaGastroRepositorio.findByNombreIgnoreCase(feriaGastro.getNombre()).isPresent()) {
            throw new IllegalArgumentException("Ya existe una Feria Gastronómica con el nombre: " + feriaGastro.getNombre());
        }
        if (feriaGastroRepositorio.findById(feriaGastro.getId()).isPresent()) {
            throw new IllegalArgumentException("Ya existe una Feria Gastronómica con el ID: " + feriaGastro.getId());
        }
    }

    private void validarUnicidadNombre(FeriaGastro feriaGastro) {
        if (feriaGastroRepositorio.findByNombreIgnoreCase(feriaGastro.getNombre()).isPresent()) {
            throw new IllegalArgumentException("Ya existe una Feria Gastronómica con el nombre: " + feriaGastro.getNombre());
        }
    }

    private FeriaGastro convertirDTOaEntidad(FeriaGastroDTO dto) {
        return FeriaGastro.builder()
                .id(dto.getId())
                .nombre(dto.getNombre())
                .precio(dto.getPrecio())
                .fechaRealizacion(dto.getFechaRealizacion())
                .tipo(dto.getTipo())
                .organizadores(new ArrayList<>())
                .build();
    }

    private FeriaGastroDTO convertirEntidadaDTO(FeriaGastro entidad) {
        FeriaGastroDTO dto = new FeriaGastroDTO();
        dto.setId(entidad.getId());
        dto.setNombre(entidad.getNombre());
        dto.setPrecio(entidad.getPrecio());
        dto.setFechaRealizacion(entidad.getFechaRealizacion());
        dto.setTipo(entidad.getTipo());
        dto.setOrganizadorIds(
                entidad.getOrganizadores() != null
                        ? entidad.getOrganizadores().stream()
                        .map(Organizador::getId)
                        .collect(Collectors.toList())
                        : new ArrayList<>()
        );
        return dto;
    }
}
