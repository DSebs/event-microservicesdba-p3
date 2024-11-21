import React, { useState } from 'react';
import { buscarOrganizadorPorId, actualizarOrganizador } from '../../services/organizadorService';

const ActualizarOrganizador = () => {
  const [id, setId] = useState('');
  const [organizador, setOrganizador] = useState({
    nombre: '',
    presupuesto: '',
    fundacion: '',
    ceo: ''
  });
  const [actualizado, setActualizado] = useState(false);

  // Manejador para buscar el organizador por ID
  const handleBuscar = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarOrganizadorPorId(id);
      setOrganizador({
        ...resultado,
        fundacion: resultado.fundacion ? resultado.fundacion.substring(0, 19) : '' // Asegurar que la fecha tenga formato correcto
      });
      setActualizado(false); // Reinicia el estado de actualización
    } catch (error) {
      alert('Error al buscar organizador: ' + error.message);
    }
  };

  // Manejador para cambiar los valores del organizador
  const handleChange = (e) => {
    const { name, value } = e.target;
    setOrganizador(prev => ({
      ...prev,
      [name]: name === 'presupuesto' ? parseFloat(value) : value // Convertir presupuesto a número
    }));
  };

  // Manejador para actualizar el organizador
  const handleActualizar = async (e) => {
    e.preventDefault();

    // Asegurarse de que la fecha tenga el formato correcto (YYYY-MM-DDTHH:mm:ss)
    const fechaAjustada = organizador.fundacion.includes(":") ? organizador.fundacion : organizador.fundacion + ":00";

    const organizadorAjustado = {
      ...organizador,
      fundacion: fechaAjustada
    };

    try {
      await actualizarOrganizador(id, organizadorAjustado);
      setActualizado(true);
    } catch (error) {
      alert('Error al actualizar organizador: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Actualizar Organizador</h2>

              {/* Formulario para buscar el organizador por ID */}
              <form onSubmit={handleBuscar}>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    placeholder="Digite el ID del Organizador"
                    required
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">Buscar Organizador</button>
                </div>
              </form>

              {organizador && organizador.nombre && (
                <form className="mt-4" onSubmit={handleActualizar}>
                  <div className="mb-3">
                    <label htmlFor="nombre" className="form-label">Nombre</label>
                    <input
                      type="text"
                      className="form-control"
                      id="nombre"
                      name="nombre"
                      value={organizador.nombre}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="mb-3">
                    <label htmlFor="presupuesto" className="form-label">Presupuesto</label>
                    <input
                      type="number"
                      step="0.1"
                      className="form-control"
                      id="presupuesto"
                      name="presupuesto"
                      value={organizador.presupuesto}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="mb-3">
                    <label htmlFor="fundacion" className="form-label">Fecha de Fundación</label>
                    <input
                      type="datetime-local"
                      className="form-control"
                      id="fundacion"
                      name="fundacion"
                      value={organizador.fundacion}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="mb-3">
                    <label htmlFor="ceo" className="form-label">CEO</label>
                    <input
                      type="text"
                      className="form-control"
                      id="ceo"
                      name="ceo"
                      value={organizador.ceo}
                      onChange={handleChange}
                      required
                    />
                  </div>

                  <div className="d-grid">
                    <button type="submit" className="btn btn-success">Actualizar Organizador</button>
                  </div>

                  {actualizado && (
                    <div className="alert alert-success mt-3" role="alert">
                      Organizador actualizado correctamente.
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

export default ActualizarOrganizador;
