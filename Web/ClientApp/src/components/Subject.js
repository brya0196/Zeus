import React from "react";

const Subject = ({subject}) => {
    return (
        <tr>
            <td>{subject.code}</td>
            <td>{subject.name}</td>
            <td>{subject.codeRequirement ? subject.codeRequirement : "n/a"}</td>
        </tr>
    );
};

export default Subject;