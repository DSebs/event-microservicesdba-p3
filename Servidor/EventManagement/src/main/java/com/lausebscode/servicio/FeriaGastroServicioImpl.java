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
        FeriaGastro feriaGastro = convertirDTOaEntidad(feriaGastroDTO);
        validarFeriaGastro(feriaGastro);
        validarUnicidad(feriaGastro);
        FeriaGastro feriaGastroGuardada = feriaGastroRepositorio.save(feriaGastro);


        if (feriaGastroDTO.getOrganizadorIds() != null && !feriaGastroDTO.getOrganizadorIds().isEmpty()) {
            List<Organizador> organizadores = organizadorRepositorio.findAllById(feriaGastroDTO.getOrganizadorIds());

            for (Organizador organizador : organizadores) {
                if (organizador.getFeriaGastro() != null) {
                    throw new IllegalArgumentException(
                            "El organizador con ID " + organizador.getId() + " ya está asociado a otra feria gastronómica."
                    );
                }
            }

            feriaGastroGuardada.getOrganizadores().clear();
            feriaGastroGuardada.getOrganizadores().addAll(organizadores);

            organizadores.forEach(org -> org.setFeriaGastro(feriaGastroGuardada));
        }

        // Retornar el DTO de la feria creada
        return convertirEntidadaDTO(feriaGastroGuardada);
    }

    public FeriaGastro buscarPorId(int id) {
        return feriaGastroRepositorio.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con ID: " + id));
    }

    @Override
    public FeriaGastroDTO buscarPorIdDTO(int id) {
        FeriaGastro feria = feriaGastroRepositorio.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con ID: " + id));
        return convertirEntidadaDTO(feria);
    }


    @Override
    public FeriaGastroDTO buscarPorNombre(String nombre) {
        if (nombre == null || nombre.trim().isEmpty()) {
            throw new IllegalArgumentException("El nombre no puede ser nulo o estar vacío");
        }

       FeriaGastro feria = feriaGastroRepositorio.findByNombreIgnoreCase(nombre)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con nombre: " + nombre));

        return convertirEntidadaDTO(feria);
    }

    public void eliminarFeriaGastro(int id) {
        FeriaGastro feriaGastro = feriaGastroRepositorio.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("No se encontró la Feria Gastronómica con ID: " + id));

        feriaGastro.getOrganizadores().forEach(organizador -> organizador.setFeriaGastro(null));
        feriaGastroRepositorio.delete(feriaGastro);
    }

    @Override
    public List<FeriaGastroDTO> listarTodasLasFeriasGastro() {
        return feriaGastroRepositorio.findAll().stream()
                .map(this::convertirEntidadaDTO)
                .collect(Collectors.toList());
    }

    @Override
    public List<FeriaGastroDTO> listarFeriasGastroMenorIgualPrecio(double precioMaximo) {
        if (precioMaximo < 0) {
            throw new IllegalArgumentException("El precio máximo no puede ser negativo");
        }
        return feriaGastroRepositorio.findByPrecioLessThanEqual(precioMaximo).stream()
                .map(this::convertirEntidadaDTO)
                .collect(Collectors.toList());
    }

    @Override
    @Transactional
    public FeriaGastroDTO actualizarFeriaGastro(int id, FeriaGastroDTO feriaGastroDTO) {
        FeriaGastro feriaGastroExistente = buscarPorId(id);

        feriaGastroExistente.setNombre(feriaGastroDTO.getNombre());
        feriaGastroExistente.setPrecio(feriaGastroDTO.getPrecio());
        feriaGastroExistente.setFechaRealizacion(feriaGastroDTO.getFechaRealizacion());
        feriaGastroExistente.setTipo(feriaGastroDTO.getTipo());

        if (feriaGastroExistente.getOrganizadores() != null) {
            feriaGastroExistente.getOrganizadores().forEach(org -> org.setFeriaGastro(null));
            feriaGastroExistente.getOrganizadores().clear();
        }

        if (feriaGastroDTO.getOrganizadorIds() != null && !feriaGastroDTO.getOrganizadorIds().isEmpty()) {
            List<Organizador> organizadores = organizadorRepositorio.findAllById(feriaGastroDTO.getOrganizadorIds());

            for (Organizador organizador : organizadores) {
                if (organizador.getFeriaGastro() != null &&
                        organizador.getFeriaGastro().getId() != feriaGastroExistente.getId()) {
                    throw new IllegalArgumentException(
                            "El organizador con ID " + organizador.getId() + " ya está asociado a otra feria gastronómica."
                    );
                }
            }
            organizadores.forEach(org -> org.setFeriaGastro(feriaGastroExistente));
            feriaGastroExistente.getOrganizadores().addAll(organizadores);
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
