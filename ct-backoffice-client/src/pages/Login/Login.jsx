import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import { login } from '../../store/actions/userAction';
import { useDispatch, useSelector } from 'react-redux';
import { Grid, Header, Form, Image, Segment, Button } from 'semantic-ui-react';

const Login = () => {
  const [password, setPassword] = useState('');
  const [email, setEmail] = useState('');
  const dispatch = useDispatch();
  const history = useHistory();
  const user = useSelector((state) => state.user);

  useEffect(() => {
    if (user.token) {
      history.push('/');
    }
  });

  const loginUser = () => {
    dispatch(login(email, password));
  };

  return (
    <>
      <Grid
        textAlign="center"
        style={{ height: '100vh' }}
        verticalAlign="middle"
      >
        <Grid.Column style={{ maxWidth: 450 }}>
          <Header as="h2" color="blue" textAlign="center">
            <Image src="logo.jpg" /> Sign in to your account
          </Header>
          <Form size="large">
            <Segment stacked>
              <Form.Input
                fluid
                icon="user"
                iconPosition="left"
                placeholder="E-mail address"
                onChange={(e) => setEmail(e.target.value)}
              />
              <Form.Input
                fluid
                icon="lock"
                iconPosition="left"
                placeholder="Password"
                type="password"
                onChange={(e) => setPassword(e.target.value)}
              />
              <p style={{ color: 'red' }}>{user.message} </p>
              <Button color="blue" fluid size="large" onClick={loginUser}>
                Login
              </Button>
            </Segment>
          </Form>
        </Grid.Column>
      </Grid>
    </>
  );
};

export default Login;
