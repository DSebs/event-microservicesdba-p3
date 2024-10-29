const AcercaDe= () => {
    return( 
    
    <div className="container d-flex align-items-center justify-content-center" style={{height: '100vh'}}>
        <div className="card p-4" style={{maxWidth: '700px'}}>
          <h2 className="text-center mb-4">Desarrollado por:</h2>
          <div className="row">
            <div className="col-6 text-center">
              <img 
                src="src\assets\laura-gomez.jpg" 
                alt="Laura Gomez" 
                className="rounded-circle mb-2" 
                style={{width: '150px', height: '150px', objectFit: 'cover'}}
              />
              <h4>Laura Gomez</h4>
            </div>
            <div className="col-6 text-center">
              <img 
                src="src\assets\sebastian-diaz.jpg" 
                alt="Sebastian Diaz" 
                className="rounded-circle mb-2" 
                style={{width: '150px', height: '150px', objectFit: 'cover'}}
              />
              <h4>Sebastian Diaz</h4>
            </div>
          </div>
          <p className="text-center mt-3">Versión 5.0</p>
        </div>
      </div>);

}


export default AcercaDe