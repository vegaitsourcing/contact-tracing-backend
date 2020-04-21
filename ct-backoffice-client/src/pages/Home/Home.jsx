import React from 'react';
import PendingList from '../../components/PendingList/PendingList';
import ConfirmedList from '../../components/ConfirmedList/ConfirmedList';
import RejectedList from '../../components/RejectedList/RejectedList';
import { Grid } from 'semantic-ui-react';

const Home = () => {
  return (
    <div className="home-container">
      <Grid divided="vertically">
        <Grid.Row columns={1}>
          <Grid.Column>
            <PendingList />
          </Grid.Column>
        </Grid.Row>

        <Grid.Row columns={2}>
          <Grid.Column>
            <ConfirmedList />
          </Grid.Column>
          <Grid.Column>
            <RejectedList />
          </Grid.Column>
        </Grid.Row>
      </Grid>
    </div>
  );
};

export default Home;
