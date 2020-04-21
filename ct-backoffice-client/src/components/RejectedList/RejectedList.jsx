import React from 'react';
import { Table, Responsive } from 'semantic-ui-react';
import { map } from 'lodash';

const RejectedList = () => {
  const rejectedCases = [
    { id: 'sdfsd', date: '04/04/2020' },
    { id: 'ewewwe', date: '04/04/2020' },
    { id: 'vsdvsdvs', date: '04/04/2020' },
  ];

  return (
    <>
      <h2> REJECTED CASES</h2>
      <Table sortable singleLine fixed>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell> Health ID </Table.HeaderCell>
            <Table.HeaderCell> Date </Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {map(rejectedCases, ({ id, date }) => (
            <Table.Row key={id}>
              <Table.Cell>
                <Responsive maxWidth={768}>Health ID:</Responsive>
                {id}
              </Table.Cell>
              <Table.Cell>
                <Responsive maxWidth={768}>Date:</Responsive>
                {date}
              </Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </>
  );
};

export default RejectedList;
