import React, { useState } from 'react';
import { buscarFeriaGastroPorId, eliminarFeriaGastro } from '../../services/feriaGastroService';

const EliminarFeria = () => {
  const [id, setId] = useState('');
  const [feria, setFeria] = useState(null);
  const [eliminado, setEliminado] = useState(false);

  // Manejador para buscar la feria por ID
  const handleBuscar = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarFeriaGastroPorId(id);
      setFeria(resultado);
      setEliminado(false); // Reinicia el estado de eliminación
    } catch (error) {
      alert('Error al buscar feria gastronómica: ' + error.message);
    }
  };

  // Manejador para eliminar la feria
  const handleEliminar = async () => {
    try {
      await eliminarFeriaGastro(feria); // Enviar el objeto feria completo
      setEliminado(true); // Indica que la eliminación fue exitosa
      setFeria(null); // Reinicia el estado de la feria
      setId(''); // Reinicia el campo de ID
    } catch (error) {
      alert('Error al eliminar feria gastronómica: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Eliminar Feria Gastronómica</h2>
              {/* Formulario para buscar la feria por ID */}
              <form onSubmit={handleBuscar}>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    placeholder="Digite el ID de la Feria"
                    required
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">
                    Buscar Feria
                  </button>
                </div>
              </form>

              {/* Información de la feria si se encuentra */}
              {feria && (
                <div className="mt-4">
                  <h5>Información de la Feria</h5>
                  <p><strong>Nombre:</strong> {feria.nombre}</p>
                  <p><strong>Precio:</strong> {feria.precio}</p>
                  <p><strong>Fecha de Realización:</strong> {new Date(feria.fechaRealizacion).toLocaleString()}</p>
                  <p><strong>Tipo:</strong> {feria.tipo}</p>
                  <div className="d-grid">
                    <button onClick={handleEliminar} className="btn btn-danger">
                      Eliminar Feria
                    </button>
                  </div>
                </div>
              )}

              {/* Mensaje de éxito al eliminar */}
              {eliminado && (
                <div className="alert alert-success mt-3" role="alert">
                  Feria eliminada correctamente.
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EliminarFeria;
