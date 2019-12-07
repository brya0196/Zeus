import React from 'react';
export default  function Seleccion() {
    return (
        <>
            <header className="page-header">
                <h2>Seleccion</h2>
                <ul className="controls">
                    <li>
                        <button className="btn btn-secondary">
                            Agregar
                        </button>
                    </li>
                </ul>
            </header>
            <section className="dashboard">
                <div className="container-fluid">
                    <table className="table table-custom">
                        <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">First</th>
                            <th scope="col">Last</th>
                            <th scope="col">Handle</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Larry</td>
                            <td>the Bird</td>
                            <td>@twitter</td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            </section>
        </>
    );
}