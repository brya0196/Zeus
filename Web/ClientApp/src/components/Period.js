import React, {Fragment} from "react";
import Subject from "./Subject";

const Periods = ({pensum}) => {
    return (
        <Fragment>
            <h3 className="text-black text-center m-3">{pensum.description}</h3>

            <table className="table table-custom table-bordered">
                <thead>
                <tr>
                    <th>Codigo</th>
                    <th>Nombre</th>
                    <th>Prerequisito</th>
                </tr>
                </thead>
                <tbody>
                {
                    pensum.careerSubjects.map((item, index) => (
                        <Subject key={index} subject={item.subject}/>
                    ))
                }
                </tbody>
            </table>
            
        </Fragment>
    );
};

export default Periods;