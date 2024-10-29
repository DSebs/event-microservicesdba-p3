package com.lausebscode.controlador;


import com.lausebscode.modelo.FeriaGastro;
import com.lausebscode.servicio.FeriaGastroServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/feriagastro")
public class FeriaGastroControlador {

    @Autowired
    private FeriaGastroServicio feriaGastroServicio;

    @PostMapping("/crear")
    public ResponseEntity<FeriaGastro> crearFeriaGastro(@RequestBody FeriaGastro feriaGastro) {
        try {
            FeriaGastro feriaGastroCreada = feriaGastroServicio.crearFeriaGastro(feriaGastro);
            return ResponseEntity.status(HttpStatus.CREATED).body(feriaGastroCreada);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/buscar/{id}")
    public ResponseEntity<FeriaGastro> buscarFeriaGastroId(@PathVariable int id) {
        try {
            FeriaGastro feriaGastro = feriaGastroServicio.buscarPorId(id);
            return ResponseEntity.ok(feriaGastro);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @GetMapping("/buscar/nombre/{nombre}")
    public ResponseEntity<FeriaGastro> buscarFeriaGastroNombre(@PathVariable String nombre) {
        try {
            FeriaGastro feriaGastro = feriaGastroServicio.buscarPorNombre(nombre);
            return ResponseEntity.ok(feriaGastro);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/eliminar")
    public ResponseEntity<Void> eliminarFeriaGastro(@RequestBody FeriaGastro feriaGastro) {
        try {
            feriaGastroServicio.eliminarFeriaGastro(feriaGastro);
            return ResponseEntity.noContent().build();
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/listar")
    public ResponseEntity<List<FeriaGastro>> listarTodasLasFeriasGastro() {
        List<FeriaGastro> feriasGastro = feriaGastroServicio.listarTodasLasFeriasGastro();
        return ResponseEntity.ok(feriasGastro);
    }

    @GetMapping("/listar/precio/{precioMaximo}")
    public ResponseEntity<List<FeriaGastro>> listarFeriasGastroMenorIgualPrecio(@PathVariable double precioMaximo) {
        List<FeriaGastro> feriasGastro = feriaGastroServicio.listarFeriasGastroMenorIgualPrecio(precioMaximo);
        return ResponseEntity.ok(feriasGastro);
    }

    @PutMapping("/{id}")
    public ResponseEntity<FeriaGastro> actualizarFeriaGastro(
            @PathVariable("id") int id,
            @RequestBody FeriaGastro nuevoFeriaGastro) {
        try {
            FeriaGastro feriaGastroActualizada = feriaGastroServicio.actualizarFeriaGastro(id, nuevoFeriaGastro);
            return ResponseEntity.ok(feriaGastroActualizada);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }
}