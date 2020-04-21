import React from 'react';
import { Table, Responsive } from 'semantic-ui-react';
import { map } from 'lodash';

const ConfirmedList = () => {
  const confirmedCases = [
    { id: 'gdfgdfgd', date: '04/04/2020' },
    { id: 'vcxvxcvcx', date: '04/04/2020' },
    { id: 'sdsdfhsa', date: '04/04/2020' },
    { id: 'gfvcxc', date: '04/04/2020' },
    { id: 'tertervvxter', date: '04/04/2020' },
  ];

  return (
    <>
      <h2> CONFIRMED CASES</h2>
      <Table sortable singleLine fixed>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell> Health ID </Table.HeaderCell>
            <Table.HeaderCell> Date </Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {map(confirmedCases, ({ id, date }) => (
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

export default ConfirmedList;
