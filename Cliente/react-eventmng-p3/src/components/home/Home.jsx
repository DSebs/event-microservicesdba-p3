import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';

const Home = () => {
  return (
    <Container fluid className="p-0">
      <Row className="justify-content-center align-items-center" style={{ height: '80vh' }}>
        <Col xs={12} md={8} lg={6} className="text-center">
          <img
            src="src\assets\banerijillo.jpg"
            alt="Bienvenida a EventManagement"
            className="img-fluid shadow-lg"
            style={{ maxHeight: '70vh', width: 'auto', borderRadius: '15px',margin: '10px' }}
          />
          <h1 className="mt-4">Bienvenido a EventManagement</h1>
          <p className="lead">Gestiona tus Ferias Gastronomicas.</p>
        </Col>
      </Row>
    </Container>
  );
};

export default Home;