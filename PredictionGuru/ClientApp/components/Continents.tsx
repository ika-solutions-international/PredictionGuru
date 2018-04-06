import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface Continent {
    id: number;
    name: string;
}

interface ContinentsDataState {
    continents: Continent[];
    loading: boolean;
}

export class ContinentsData extends React.Component<RouteComponentProps<{}>, ContinentsDataState> {
    constructor() {
        super();
        this.state = { continents: [], loading: true };

        fetch('api/ContinentsAPI/Continents')
            .then(response => response.json() as Promise<Continent[]>)
            .then(data => {
                this.setState({ continents: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ContinentsData.renderContinentsTable(this.state.continents);

        return <div>
            <h1>Continents</h1>
            <p>Continents data from database!</p>
            {contents}
        </div>;
    }

    private static renderContinentsTable(continents: Continent[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {continents.map(continent =>
                    <tr key={continent.id}>
                        <td>{continent.id}</td>
                        <td>{continent.name}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}
