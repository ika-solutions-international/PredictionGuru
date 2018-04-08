import * as React from 'react';
import * as $ from 'jquery';
import * as bootstrap from 'bootstrap';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface Continent {
    id: number;
    name: string;
}

interface ContinentsDataState {
    continents: Continent[];
    loading: boolean;
    continentId: string;
    continentName: string;
}

export class ContinentsData extends React.Component<RouteComponentProps<{}>, ContinentsDataState> {
    constructor() {
        super();
        this.state = { continents: [], loading: true, continentId: "0", continentName: "" };

        fetch('api/ContinentsAPI/Continents')
            .then(response => response.json() as Promise<Continent[]>)
            .then(data => {
                this.setState({ continents: data, loading: false });
            });
    }

    handleAddNew = (event: React.MouseEvent<HTMLButtonElement>) => {
        this.setState({
            continentId: "0",
            continentName: ""
        },
        () => {
            $("#winAddNewContinent").modal("show");
        });
    }

    handleChange = (event: React.FormEvent<HTMLInputElement>) => {
        this.setState({ continentName: event.currentTarget.value });
    }

    handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        this.setState({ loading: true });

        var data = new FormData();
        data.append("id", this.state.continentId);
        data.append("name", this.state.continentName);

        fetch('api/ContinentsAPI/SaveContinent', {
            method: "POST",
            body: data
        })
        .then(response => response.json() as Promise<Continent[]>)
        .then(data => {
            this.setState({ continents: data, loading: false, continentId: "0", continentName: "" });

            $("#winAddNewContinent").modal("hide");
        });

        event.preventDefault();
    }

    handleEdit = (event: React.MouseEvent<HTMLButtonElement>) => {
        this.setState({
            continentId: $(event.currentTarget).attr("data-id") as string,
            continentName: $(event.currentTarget).attr("data-name") as string
        },
        () => {
            $("#winAddNewContinent").modal("show");
        });
    }

    handleDelete = (event: React.MouseEvent<HTMLButtonElement>) => {
        this.setState({
            continentId: $(event.currentTarget).attr("data-id") as string
        },
        () => {
            if (confirm("Are you sure to delete this record?")) {
                this.setState({ loading: true });

                var data = new FormData();
                data.append("id", this.state.continentId);

                fetch('api/ContinentsAPI/DeleteContinent', {
                    method: "POST",
                    body: data
                })
                .then(response => response.json() as Promise<Continent[]>)
                .then(data => {
                    this.setState({ continents: data, loading: false, continentId: "0", continentName: "" });
                });
            }
        });        
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderContinentsTable(this.state.continents);

        return <div>
            <h1>Continents</h1>
            <p>Continents data from database!</p>
            <button type="button" onClick={this.handleAddNew}>Add new Continent</button>
            {contents}

            <div className="modal fade" id="winAddNewContinent" tabIndex={-1} role="dialog" aria-labelledby="winAddNewContinentLabel" aria-hidden="true">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 className="modal-title" id="winAddNewContinentLabel">Add new Continent</h4>
                        </div>
                        <form onSubmit={this.handleSubmit}>
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

    renderContinentsTable(continents: Continent[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {continents.map(continent =>
                    <tr key={continent.id}>
                        <td>{continent.id}</td>
                        <td>{continent.name}</td>
                        <td><button type="button" data-id={continent.id} data-name={continent.name} onClick={this.handleEdit}>Edit</button></td>
                        <td><button type="button" data-id={continent.id} onClick={this.handleDelete}>Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}