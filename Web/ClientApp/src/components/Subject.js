import React, {Fragment} from "react";

const Subject = ({subject}) => {
  return(
      <table className="table table-custom table-bordered">
          <thead>
            <tr>
                <th>Codigo</th>
                <th>Nombre</th>
                <th>Prerequisito</th>
            </tr>
          </thead>
          <tbody>
            <tr>
                <td>{subject.code}</td>
                <td>{subject.name}</td>
                <td>{ subject.codeRequirement ? subject.codeRequirement : "n/a" }</td>
            </tr>
          </tbody>
      </table>
  );  
};

export default Subject;