import React, {Component} from 'react';
import {getSelection} from "../../services";
import {Link} from "react-router-dom";

export default class Seleccion extends Component {

    constructor(props) {
        super(props);
        this.eliminarMateria = this.eliminarMateria.bind(this);
        this.state = {
            data: {
            }
        };
    }
    componentDidMount() {
        getSelection()
            .then(({data}) =>{
                console.log(data)

            })
            .catch((error) => {

            });
    }
    eliminarMateria(id){
        console.log(id)
    }
    render() {
        const { title: mainTitle } = this.props;

        return (
            <>
                <header className="page-header">
                    <h2>{mainTitle}</h2>
                    <ul className="controls">
                        <li>
                            <Link to="agregarMateria" className="btn btn-secondary">
                                Agregar
                            </Link>
                        </li>
                    </ul>
                </header>
                <section className="dashboard">
                    <div className="container-fluid">
                        <table className="table table-custom">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Código</th>
                                    <th>Nombre</th>
                                    <th>Prerrequisito</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td className="controls" onClick={()=>this.eliminarMateria(12)}>
                                            <i className="fa fa-trash-o" aria-hidden="true"></i>
                                    </td>
                                    <td>DER-313</td>
                                    <td>Derechos Intelectuales</td>
                                    <td>CodeRequirement</td>
                                </tr>
                                <tr>
                                    <td className="controls">
                                            <i className="fa fa-trash-o" aria-hidden="true"></i>
                                    </td>
                                    <td>DER-313</td>
                                    <td>Derechos Intelectuales</td>
                                    <td>CodeRequirement</td>
                                </tr>
                                <tr>
                                    <td className="controls">
                                            <i className="fa fa-trash-o" aria-hidden="true"></i>
                                    </td>
                                    <td>DER-313</td>
                                    <td>Derechos Intelectuales</td>
                                    <td>CodeRequirement</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </section>
            </>
        )
    }
}