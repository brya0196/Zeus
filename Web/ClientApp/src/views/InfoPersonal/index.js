import React, { Component } from 'react';
import {getUserInfo} from "../../services";

export default class InfoPersonal extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            data:""
        };
    }
    componentDidMount() {
        getUserInfo()
            .then((response) =>{
                this.setState({ data: JSON.stringify(response.data) });

            })
            .catch((error) => {

            });
    }

    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value  });
    }

    render() {
        return (
            <div className="">
                {this.state.data}
            </div>
        )
    }
}
