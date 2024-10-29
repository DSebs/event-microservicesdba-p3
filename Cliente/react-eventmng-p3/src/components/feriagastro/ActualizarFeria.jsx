import React, { useState } from 'react';
import { buscarFeriaGastroPorId, actualizarFeriaGastro } from '../../services/feriaGastroService';

const ActualizarFeria = () => {
  const [id, setId] = useState('');
  const [feria, setFeria] = useState({});
  const [actualizado, setActualizado] = useState(false);

  const handleBuscar = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarFeriaGastroPorId(id);
      setFeria(resultado);
      setActualizado(false);
    } catch (error) {
      alert('Error al buscar feria: ' + error.message);
    }
  };

  const handleActualizar = async (e) => {
    e.preventDefault();
    try {
      const tieneSegundos = feria.fechaRealizacion.split(":").length === 3;
      const fechaAjustada = tieneSegundos ? feria.fechaRealizacion : feria.fechaRealizacion + ":00";

      const feriaAjustada = { ...feria, fechaRealizacion: fechaAjustada };

      await actualizarFeriaGastro(id, feriaAjustada);
      setActualizado(true);
    } catch (error) {
      alert('Error al actualizar feria: ' + error.message);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFeria(prev => ({
      ...prev,
      [name]: name === 'precio' ? parseFloat(value) : value // Convertir precio a número
    }));
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Actualizar Feria</h2>
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
                  <button type="submit" className="btn btn-primary">Buscar Feria</button>
                </div>
              </form>

              {feria && (
                <form className="mt-4" onSubmit={handleActualizar}>
                  <div className="mb-3">
                    <label htmlFor="nombre" className="form-label">Nombre</label>
                    <input
                      type="text"
                      className="form-control"
                      id="nombre"
                      name="nombre"
                      value={feria.nombre}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="mb-3">
                    <label htmlFor="precio" className="form-label">Precio</label>
                    <input
                      type="number"
                      step="0.1"
                      className="form-control"
                      id="precio"
                      name="precio"
                      value={feria.precio}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="mb-3">
                    <label htmlFor="fechaRealizacion" className="form-label">Fecha de Realización</label>
                    <input
                      type="datetime-local"
                      className="form-control"
                      id="fechaRealizacion"
                      name="fechaRealizacion"
                      value={feria.fechaRealizacion}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="mb-3">
                    <label htmlFor="tipo" className="form-label">Tipo (Comida)</label>
                    <input
                      type="text"
                      className="form-control"
                      id="tipo"
                      name="tipo"
                      value={feria.tipo}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="d-grid">
                    <button type="submit" className="btn btn-success">Actualizar Feria</button>
                  </div>

                  {actualizado && (
                    <div className="alert alert-success mt-3" role="alert">
                      Feria actualizada correctamente.
                    </div>
                  )}
                </form>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ActualizarFeria;