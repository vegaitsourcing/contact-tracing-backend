import React from 'react';
import './App.scss';
import Home from './pages/Home/Home';
import { Redirect, withRouter } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import { Switch, Route } from 'react-router';
import Login from './pages/Login/Login';

const App = (props) => {
  const loggedOutPaths = ['/login'];

  const redirect =
    !localStorage.getItem('token') &&
    !loggedOutPaths.includes(props.location.pathname) ? (
      <Redirect to="/login" />
    ) : localStorage.getItem('token') &&
      loggedOutPaths.includes(props.location.pathname) ? (
      <Redirect to="/" />
    ) : null;

  return (
    <>
      {redirect}
      {!loggedOutPaths.includes(props.location.pathname) && (
        <main>
          <Layout>
            <Routes />
          </Layout>
        </main>
      )}
      {loggedOutPaths.includes(props.location.pathname) && <Routes />}
    </>
  );
};

const Routes = () => {
  return (
    <Switch>
      <Route exact path="/" component={Home} />
      <Route exact path="/login" component={Login} />
    </Switch>
  );
};

export default withRouter(App);
