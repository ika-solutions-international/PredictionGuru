import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ContinentsData } from './components/Continents';
import { TeamTypes } from './components/TeamType/TeamType';


export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata' component={ FetchData } />
    <Route path='/api/continents' component={ContinentsData} />
    <Route path='/teamTypes' component={TeamTypes} />
</Layout>;