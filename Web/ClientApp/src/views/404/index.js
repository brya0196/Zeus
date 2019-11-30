import React from 'react';
export default function NotFound_404() {
      return (
          <>
              <section className="404">
                  <div className="container-fluid">
                      <div className="d-flex justify-content-center align-items-center" style={{ height: "calc(100vh - 50px)"}}>
                          <h1 className="mr-3 pr-3 align-top border-right inline-block align-content-center">404</h1>
                          <div className="inline-block align-middle">
                              <h2 className="font-weight-normal lead" id="desc">Datos no encontrado</h2>
                          </div>
                      </div>
                  </div>
              </section>
          </>
        );

}
