import React, { Component } from 'react';
import {API} from '../../services';
import { connect } from 'react-redux';
import { setCurrentUserInfo } from '../../redux/actions/authentication';
import {Button, Spinner } from 'react-bootstrap';

class Login extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            errors: [],
            loading: false,
            userName: "",
            password: "",
            //remeberMe: false
        };
    }
    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value  });
    }
    handleSubmit = (e) =>{
        e.preventDefault()
        this.setState({loading:true});
        const { userName, password} = this.state

        API.post('/Login',{
            usuInicioSesion: userName, usuClave: password
        })
        .then((response) =>{
            const { from } = this.props.location.state || { from: { pathname: '/' } }
            localStorage.setItem("_token", response.data.token);
            this.props.setCurrentUserInfo(response.data.token);
            window.location.href = from.pathname;
        })
        .catch((error) => {
            if(error.response)
                if(error.response.data)
                    this.setState({errors:error.response.data});
                
            this.setState({loading:false});
        });
    };
    render() {
        const { loading, userName, password } = this.state;
        return (
            <div className="login-page">
                <div className="form">
                    <div className="logo">
                        <img src="https://eljacaguero.com/wp-content/uploads/2012/10/Logo-UAPA-e1350509365799.png" alt="uapa" className="img-fluid"/>
                    </div>
                    <h3>
                        Iniciar sesión
                    </h3>
                    <form onSubmit={this.handleSubmit}>
                        {this.state.errors && typeof this.state.errors === "string" &&
                            <div className="alert alert-danger" role="alert" >
                                 {this.state.errors }
                            </div>
                        }
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon1"><i className="fa fa-user"></i> </span>
                            </div>
                            <input type="text" name="userName" className="form-control" value={userName} onChange={this.handleChange} placeholder="Matricula" required />
                        </div>
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon1"><i className="fa fa-key"></i> </span>
                            </div>
                            <input type="password" className="form-control" name="password" value={password} onChange={this.handleChange} required placeholder="Contraseña" />
                        </div>
                        <div className="row mb-3">
                            <div className="col-12">
                                <div className="custom-control custom-checkbox">
                                    <input type="checkbox" className="custom-control-input" id="customCheck1" />
                                    <label className="custom-control-label" htmlFor="customCheck1"> Recordar usuario</label>
                                </div>
                            </div>
                        </div>
                        <Button type="submit" variant="primary"  disabled={loading} >
                            {loading && <Spinner
                                as="span"
                                animation="border"
                                size="sm"
                                role="status"
                                aria-hidden="true"
                            /> } Acceder
                        </Button>
                    </form>
                    <a className="text-muted text-center" href="/">¿Olvidaste tu contraseña?</a>
                </div>
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    auth: state.auth,
    errors: state.errors
});
export  default connect(mapStateToProps, { setCurrentUserInfo })(Login)
