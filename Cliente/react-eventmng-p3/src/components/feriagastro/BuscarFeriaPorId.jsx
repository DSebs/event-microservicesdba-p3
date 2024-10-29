import React, { useState } from 'react';
import { buscarFeriaGastroPorId } from '../../services/feriaGastroService';

const BuscarFeriaGastroID = () => {
  const [id, setId] = useState('');
  const [feria, setFeria] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarFeriaGastroPorId(id);
      setFeria(resultado);
    } catch (error) {
      alert('Error al buscar la feria: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Buscar Feria por ID</h2>
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    placeholder="Digite el ID"
                    required
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">Buscar</button>
                </div>
              </form>
              {feria && (
                <div className="mt-4">
                  <h3>Resultado:</h3>
                  <p>ID: {feria.id}</p>
                  <p>Nombre: {feria.nombre}</p>
                  <p>Precio: ${feria.precio}</p>
                  <p>Fecha de Realización: {new Date(feria.fechaRealizacion).toLocaleDateString()}</p>
                  <p>Tipo: {feria.tipo}</p>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BuscarFeriaGastroID;
