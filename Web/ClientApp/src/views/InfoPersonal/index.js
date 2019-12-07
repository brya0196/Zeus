import React, { Component } from 'react';
import {getUserInfo} from "../../services";

export default class InfoPersonal extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            data: {
                birthdate: "",
                career: "",
                careerId: "",
                cedula: "",
                coursesUsers: "",
                email: "",
                gender: "",
                genderId: "",
                id: "",
                lastname: "",
                matricula: "",
                name: "",
                phone: "",
            }
        };
    }
    componentDidMount() {
        getUserInfo()
            .then(({data}) =>{
                if(data.length){
                    this.setState({ data:data[0] });
                }

            })
            .catch((error) => {

            });
    }

    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value  });
    }

    render() {
        const { title: mainTitle } = this.props;
        const {  birthdate, career, cedula, email, gender, id, lastname, matricula, 
            name, phone } = this.state.data;
        return (
            <>
                <header className="page-header">
                    <h2>{mainTitle}</h2>
                </header>
                <section className="infPersonal">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Carrera</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={career}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Matrícula</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={matricula}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Id</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={id}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Nombres</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={name}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Apellido</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={lastname}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Número Documento Identidad</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={cedula}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Documento Identidad</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue="Cédula"/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Sexo</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={gender}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Teléfono</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={phone}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Correo Electrónico</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={email}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-6">
                                <div className="form-group row">
                                    <label className="col-sm-4">Fecha Nacimiento</label>
                                    <div className="col-sm-8">
                                        <input type="text" readOnly className="form-control-plaintext" defaultValue={birthdate}/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </section>
            </>
        )
    }
}
