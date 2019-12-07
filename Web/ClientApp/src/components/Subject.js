import React, {Fragment} from "react";

const Subject = ({subject}) => {
  return(
      <table className="table table-bordered table-active">
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
                <td>{subject.codeRequirement}</td>
            </tr>
          </tbody>
      </table>
  );  
};

export default Subject;