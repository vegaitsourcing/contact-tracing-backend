import React, { useState } from 'react';
import { Table, Button, Responsive } from 'semantic-ui-react';
import { map } from 'lodash';
import { Confirm } from 'semantic-ui-react';

const PendingList = () => {
  const cases = [
    { id: 'fdsfsdf', date: '04/04/2020' },
    { id: 'fsdfsdfgfdgdf', date: '04/04/2020' },
    { id: 'vsdvsdvs', date: '04/04/2020' },
  ];
  const [showConfirmModal, setShowConfirmModal] = useState(false);
  const [showRejectModal, setShowRejectModal] = useState(false);

  const openConfirmModal = (id) => {
    setShowConfirmModal(true);
  };

  const openRejectModal = (id) => {
    setShowRejectModal(true);
  };

  const approveCase = (id) => {
    alert(`${id} APPROVED`);
    setShowConfirmModal(false);
  };
  const declineCase = (id) => {
    alert(`${id} DECLINED`);
    setShowRejectModal(false);
  };

  return (
    <>
      <h2> PENDING CASES</h2>
      <Table className="food-list-table" sortable singleLine fixed>
        <Table.Header className="food-list-table-header">
          <Table.Row>
            <Table.HeaderCell> Health ID </Table.HeaderCell>
            <Table.HeaderCell> Date </Table.HeaderCell>
            <Table.HeaderCell></Table.HeaderCell>
            <Table.HeaderCell></Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {map(cases, ({ id, date }) => (
            <Table.Row className="food-list-table-row" key={id}>
              <Table.Cell>
                <Responsive maxWidth={768}>Health ID:</Responsive>
                {id}
              </Table.Cell>
              <Table.Cell>
                <Responsive maxWidth={768}>Date:</Responsive>
                {date}
              </Table.Cell>
              <Table.Cell>
                <div>
                  <Button color="blue" onClick={openConfirmModal}>
                    Confirm Case
                  </Button>
                  <Confirm
                    open={showConfirmModal}
                    cancelButton="Cancel"
                    header="Are you sure that you want to confirm this case?"
                    content={`Health ID: ${id}`}
                    confirmButton="Confirm positive case"
                    onCancel={() => setShowConfirmModal(false)}
                    onConfirm={approveCase}
                  />
                </div>
              </Table.Cell>
              <Table.Cell>
                <div>
                  <Button color="red" onClick={openRejectModal}>
                    Reject Case
                  </Button>
                  <Confirm
                    open={showRejectModal}
                    cancelButton="Cancel"
                    header="Are you sure that you want to reject this case?"
                    content={`Health ID: ${id}`}
                    confirmButton="Reject positive case"
                    onCancel={() => setShowRejectModal(false)}
                    onConfirm={declineCase}
                  />
                </div>
              </Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </>
  );
};

export default PendingList;
