import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as Model from '../Models/Models';
//import { render } from 'react-dom';

import * as Modal from 'react-modal';
import { CreateEdit } from './CreateEdit';
import { Details } from './Details';
//import { Props } from 'react-modal';


interface TeamTypeState {
    teamTypes: Model.TeamType[]
    loading: boolean,
    showCreate: boolean,
    showEdit: boolean,
    showDetails: boolean,
    activeId: number
}

export class TeamTypes extends React.Component<RouteComponentProps<{}>, TeamTypeState>{
    constructor() {
        super();
        this.state = {
            teamTypes: [],
            loading: true,
            showCreate: false,
            showEdit: false,
            showDetails: false,
            activeId: 0
        };
        fetch('./api/TeamTypes')
            .then(response => response.json() as Promise<Model.TeamType[]>)
            .then(data => {
                this.setState({ teamTypes: data, loading: false, });
            })
    }

    handleCreate() {
        this.setState({ showCreate: true, showDetails: false, showEdit: false, activeId: 0 })
    }

    handleEdit(id: number) {
        this.setState({ showEdit: true, showDetails: false, showCreate: false, activeId: id })
    }

    handleDetails(id: number) {
        this.setState({ showDetails: true, showCreate: false, showEdit: false, activeId: id })
    }

    handleDelete(id: number) {
        if (!confirm('Are you sure you want to delete this?'))
            return
        fetch('./api/TeamTypes/' + id, { method: 'delete' })
            .then(data => {
                this.setState(
                    {
                        teamTypes: this.state.teamTypes.filter((rec) => {
                            return (rec.id != id);
                        })
                    });
            });
    }


    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderTable(this.state.teamTypes);
        let popup = this.renderPopup();

        return <div>
            <h1>Team Types</h1>
            <button className="action" onClick={this.handleCreate.bind(this)}>Create</button>
            {contents}
            {popup}
        </div>;
    }

    private renderPopup() {
        if (!this.state.showCreate && !this.state.showEdit && !this.state.showDetails)
            return null
        return <Modal isOpen={true} contentLabel="Crawl">
            <button onClick={this.closeModal.bind(this)}
                className="action"
                title="close">X</button>
            {this.renderPopupContent()}
        </Modal>
    }

    private renderPopupContent() {
        if (this.state.showCreate) {
            return <CreateEdit id={this.state.activeId} dbaction="create"
                onSave={this.handlePopupSave.bind(this)} />
            
        }
        if (this.state.showEdit) {
            return <CreateEdit id={this.state.activeId} dbaction="edit"
                onSave={this.handlePopupSave.bind(this)} />
        }
        if (this.state.showDetails) {
            return <Details id={this.state.activeId} />
        }
    }

    closeModal() {
        this.setState({ showDetails: false, showCreate: false, showEdit: false });
    }

    handlePopupSave(success: boolean, updateData: any) {
        if (success)
            this.setState({ showCreate: false, showEdit: false, teamTypes : updateData });
    }

    renderTable(teamTypes: Model.TeamType[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {teamTypes.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>
                            <button className="action" onClick={(id) => this.handleDelete(item.id)}>X</button>
                            <button className="action" onClick={(id) => this.handleEdit(item.id)}>Edit</button>
                            <button className="action" onClick={(id) => this.handleDetails(item.id)}>Details</button>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}


