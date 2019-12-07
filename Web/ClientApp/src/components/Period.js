import React, {Fragment} from "react";
import Subject from "./Subject";

const Periods = ({pensum}) => {
    return (
        <Fragment>
            <h3 className="text-black text-center mb-3">{pensum.description}</h3>
            {
                pensum.careerSubjects.map((item, index) => (
                    <Subject key={index} subject={item.subject}/>
                ))
            }
        </Fragment>
    );
};

export default Periods;