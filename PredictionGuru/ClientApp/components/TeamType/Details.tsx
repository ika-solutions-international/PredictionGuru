import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as Models from '../Models/Models';

interface DetailsState {
    teamType: Models.TeamType;
    loading: boolean;
}

interface DetailsProps {
    id: number
}

export class Details extends React.Component<any, DetailsState>{

    constructor(props : any) {
        super(props);
        //this.loadCommentsFromServer = this.loadCommentsFromServer.bind(this)
        this.state = { teamType: new Models.TeamType(), loading: true };
        fetch('./api/TeamTypes/' + this.props.id)
            .then(response => response.json() as Promise<Models.TeamType>)
            .then(data => {
                this.setState({ teamType: data, loading: false });
            })
    }

    //loadCommentsFromServer(props) {
    //    console.log(props);
    //}

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Details.renderDetails(this.state.teamType);

        return <div>
            <h1>Team Types Details</h1>
            {contents}
        </div>
    }

    private static renderDetails(item: Models.TeamType) {
        return <div className="details">
            <label>Id</label>
            <div>{item.id}</div>
            <label>Name</label>
            <div>{item.name}</div>
        </div>;
    }
}