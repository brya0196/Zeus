import React, {Fragment} from "react";

const Subject = ({subject}) => {
  return(
      <table>
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