import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import './form.css';
import { TeamType } from '../Models/Models';
import * as Models from '../Models/Models';


interface CreateEditState {
    teamType: TeamType;
    loading: boolean;
    save: boolean
}
interface CreateEditProps {
    id: number
    dbaction: string
    onSave?: any /* event*/
}


export class CreateEdit extends React.Component<CreateEditProps, CreateEditState> {
    constructor(props: CreateEditProps) {
    super(props);
        if (this.props.dbaction == "edit") {
            this.state = {
                teamType: new Models.TeamType(), loading: true, save: false
            }
            fetch('./api/TeamTypes/' + this.props.id, { method: 'get' })
                .then(response => response.json() as Promise<Models.TeamType>)
                .then(data => {
                    this.setState({ teamType: data, loading: false });
        });
        } else
            this.state = { teamType: new Models.TeamType(), loading: false, save: false }
    }
    handleSave(e : any) {
        e.preventDefault();
        let method: string = (this.props.dbaction == "edit" ? "put" : "post");
        let itemId: string = (this.props.dbaction == "edit" ? this.props.id : "") as string;
        let form: Element = document.querySelector('#formCreateEdit') as Element;
        let id = document.getElementById('Id') as HTMLInputElement;
        fetch('./api/TeamTypes/' + itemId,
            {
                method: method,
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(this.formToJson(form))
            })
            .then(data => {
                this.setState({ save: false });
                fetch('./api/TeamTypes')
                    .then(response => response.json() as Promise<Models.TeamType[]>)
                    .then(updatedData => {
                        this.props.onSave(true, updatedData);
                    })
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderForm(this.state.teamType);
        return <div>
            <h1>{this.props.dbaction == "edit" ? "Edit TeamType" : "Create TeamType"}</h1>
            {contents}
        </div>;
    }

    private renderForm(item: Models.TeamType) {
        if (this.props.dbaction != "edit")
            item = new Models.TeamType()
        return <form id='formCreateEdit'>
            {this.props.dbaction == 'edit' ? <input type='hidden' id='Id' name='Id' value={item.id} /> : null}
            <label>Name</label>
            <input id='Name' name='Name' type='text' defaultValue={item.name != null ? (item.name + '') : ''} />
            <button onClick={this.handleSave.bind(this)} >Submit</button>
        </form>;
    }

    /* utils*/
    isValidElement = (element : any) => {
        return element.name && element.value;
    };
    isValidValue = (element : any) => {
        return (['checkbox', 'radio'].indexOf(element.type) == -1 || element.checked);
    };
    formToJson = (elements : any) => [].reduce.call(elements, (data : any , element : any) => {
        console.log('formToJson()', element)
        if (this.isValidElement(element) && this.isValidValue(element)) {
            data[element.name] = element.value;
        }
        return data;
    }, {});
}
    