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
    continentName: string;
}

export class ContinentsData extends React.Component<RouteComponentProps<{}>, ContinentsDataState> {
    constructor() {
        super();
        this.state = { continents: [], loading: true, continentName: "" };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        fetch('api/ContinentsAPI/Continents')
            .then(response => response.json() as Promise<Continent[]>)
            .then(data => {
                this.setState({ continents: data, loading: false });
            });
    }

    handleChange = (event: React.FormEvent<HTMLInputElement>) => {
        this.setState({ continentName: event.currentTarget.value });
    }

    handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        this.setState({ loading: true });

        fetch('api/ContinentsAPI/SaveContinent', {
                method: "POST",
                body: JSON.stringify({ Name: this.state.continentName }),
                headers: { "Content-Type": "application/json" }
            })
            .then(response => response.json() as Promise<Continent[]>)
            .then(data => {
                this.setState({ continents: data, loading: false, continentName: "" });
            });


        //alert('A name was submitted: ' + this.state.continentName);
        event.preventDefault();
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ContinentsData.renderContinentsTable(this.state.continents);

        return <div>
            <h1>Continents</h1>
            <p>Continents data from database!</p>
            <button type="button" data-toggle="modal" data-target="#winAddNewContinent">Add new Continent</button>
            {contents}

            <div className="modal fade" id="winAddNewContinent" tabIndex={-1} role="dialog" aria-labelledby="winAddNewContinentLabel" aria-hidden="true">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <form onSubmit={this.handleSubmit}>
                            <div className="modal-header">
                                <h5 className="modal-title" id="winAddNewContinentLabel">Modal title</h5>
                                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div className="modal-body">                            
                                <label>
                                    Continent Name:&nbsp;
                                    <input type="text" value={this.state.continentName} onChange={this.handleChange} />
                                </label>                            
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                                <button type="submit" className="btn btn-primary">Save changes</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>;
    }

    private static renderContinentsTable(continents: Continent[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {continents.map(continent =>
                    <tr key={continent.id}>
                        <td>{continent.id}</td>
                        <td>{continent.name}</td>
                        <td><button type="button">Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}
